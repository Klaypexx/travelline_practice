import arrowIcon from "../icon-arrow-up.svg";
import { RouteType } from "../routesList";
import { openBlock } from "./openBlock";
import "../style.css";

export const createRouteNode = (route: RouteType) => {
    return `
      <div class="route route-${route.method.toLowerCase()}" id=${route.id}>
        <div class="route-header">
          <button class="route-summary">
            <div class="route-summary-method">${route.method}</div>
            <span class="route-summary-path">${route.path}</span>
            <div class="route-summary-arrow"><img class="arrow arrow-rotate" src=${arrowIcon} /></div>
          </button>
        </div>
        ${openBlock(route)}
      </div>`;
};