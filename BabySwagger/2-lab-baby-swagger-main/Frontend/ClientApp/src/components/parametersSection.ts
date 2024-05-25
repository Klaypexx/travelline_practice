import { RouteType } from "../routesList"

export const parametersSection = (route: RouteType) => {
    return `
        <div class="parameters-section">
            <div class="opblock-section-header">
                <div class="tab-header">
                    <h4 class="parameters-title">
                    <span>
                        Parameters
                    </span>
                    </h4>
                </div>
            </div>
            <div class="parameters-container">
                ${route.parameters ? 
                    `
                    <div class="parameters-block">
                        <div class="parameters-col_name">
                            <div class="parameter__name">
                                ${Object.keys(route.parameters)}
                                <span> *</span>
                            </div>
                            <div class="parameter__type">
                                ${Object.values(route.parameters)[0]}
                            </div>
                        </div>
                        <div class="parameters-col_description">
                            <input type="text" placeholder=${Object.keys(route.parameters)} class="parameters-col_input" value>
                        </div>
                    </div>` : ``
                }
            </div>
        </div>
    `
}