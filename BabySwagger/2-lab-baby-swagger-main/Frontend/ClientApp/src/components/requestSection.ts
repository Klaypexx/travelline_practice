import { RouteType } from "../routesList";

export const requestSection = (route: RouteType) => {
    return `
        <div class="request-section">
            <div class="opblock-section-header">
                <div class="tab-header">
                    <h4 class="parameters-title">
                    <span>
                        Request body
                    </span>
                    </h4>
                </div>
            </div>
            <div class="opblock-description-wrapper">
                <div class="body-param">
                    <textarea type="text" class="body-param__text">${JSON.stringify(route.body, null, 2).trim()}</textarea>
                </div>
            </div>
        </div>
    `
}