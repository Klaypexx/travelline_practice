import { RouteType } from "./routesList";

const routeButton = (requestDiv: HTMLElement | null) => {
    const routeBtn = requestDiv?.querySelector<HTMLDivElement>('.route-summary');
    const openWrapper = requestDiv?.querySelector<HTMLDivElement>('.opblock-wrapper');
    const routeHeader = requestDiv?.querySelector<HTMLDivElement>('.route-header');
    const arrowImg = requestDiv?.querySelector<HTMLImageElement>('.arrow'); 

    routeBtn?.addEventListener('click', () => {
        openWrapper?.classList.toggle('close');
        routeHeader?.classList.toggle('is-open');
        arrowImg?.classList.toggle('arrow-rotate');
    })
}

const executeButton = (requestDiv: HTMLElement | null, route: RouteType) => {
    const responseSection = requestDiv?.querySelector<HTMLDivElement>('.response-section');
    const openBlock = requestDiv?.querySelector<HTMLDivElement>('.opblock-execute');
    const executeBtn = openBlock?.querySelector<HTMLButtonElement>('.execute-button');
    const clearBtn = openBlock?.querySelector<HTMLButtonElement>('.clear-button');

    executeBtn?.addEventListener('click', () => {
        fetchResponse(requestDiv, route)
        if (openBlock?.classList.contains('opblock-execute')) {
            openBlock?.classList.remove('opblock-execute');
            openBlock?.classList.add('btn-group');
            clearBtn?.classList.remove('close');
        }
    })

    clearBtn?.addEventListener('click', () => {
        openBlock?.classList.remove('btn-group');
        openBlock?.classList.add('opblock-execute');
        clearBtn?.classList.add('close');
        responseSection?.classList.add('close');
    })
}

export const fetchResponse = async (requestDiv: HTMLElement | null, route: RouteType) => {
    const parameterInput = requestDiv?.querySelector<HTMLInputElement>('.parameters-col_input');
    if (route.parameters && !parameterInput?.value) {
        return;
    }
    
    const id = route.path.includes('{id}') && parameterInput ? parameterInput.value : '';
    const email = route.path.includes('{email}') && parameterInput ? parameterInput.value : '';

    const baseUrl = route.path
    .replace('{id}', id)
    .replace('{email}', email.toString());

    const requestTextArea = requestDiv?.querySelector<HTMLTextAreaElement>(`.body-param__text`);


    const response = await fetch(`http://localhost:5154${baseUrl}`, {
        method: route.method,
        headers: {
            "Content-Type": "application/json;charset=utf-8",
        },
        body: requestTextArea?.value
    });
    
    responseBlock(response, requestDiv);
  }
  
  
const responseBlock = async (response: Response, requestDiv: HTMLElement | null) => {
    const requestUrl = requestDiv?.querySelector<HTMLSpanElement>('.request-url .microlight');
    const responseCode = requestDiv?.querySelector<HTMLSpanElement>('.response-code .microlight');
    const responseBody = requestDiv?.querySelector<HTMLSpanElement>('.response-body .microlight');
    const responseHeader = requestDiv?.querySelector<HTMLSpanElement>('.response-headers .microlight');
    const responseSection = requestDiv?.querySelector<HTMLDivElement>('.response-section');

    responseSection?.classList.remove('close');

    if (requestUrl) {
        requestUrl.innerHTML = `${response.url}`;
    };

    if (responseCode) {
        responseCode.innerHTML = `${response.status} ${response.statusText}` ;
    };

    if (responseBody) {
        const formattedData = await response.json();
        responseBody.innerHTML = `${JSON.stringify(formattedData, null, 2)}`;  
    };

    if (responseHeader) {
        const headersHTML = Array.from(response.headers.entries())
        .map(([name, value]) => `${name} : ${value}\n`)
        .join('');
        responseHeader.innerHTML = `${headersHTML}`;
    };
}


export const swaggerLogic = (route: RouteType) => {
    const requestDiv = document.getElementById(route.id);
    routeButton(requestDiv);
    executeButton(requestDiv, route);
}
