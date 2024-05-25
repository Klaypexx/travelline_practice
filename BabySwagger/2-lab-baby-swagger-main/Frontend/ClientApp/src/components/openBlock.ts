import { RouteType } from "../routesList";
import { parametersSection } from "./parametersSection";
import { requestSection } from "./requestSection";
import { responseSection } from "./responseSection";
import { executeBtn } from "./executeBtn";

export const openBlock = (route: RouteType) => {
    return `
        <div class="opblock-wrapper close">
          <div class="opblock-body">
            ${parametersSection(route)}
            ${route.body ? requestSection(route) : ""}
            ${executeBtn()}
            ${responseSection()}
          </div>
        </div>
    `
}