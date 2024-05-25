import {createRouteNode} from "./createRouteNode"
import { RouteType } from "../routesList";
import "../style.css";

export const createHtml = (routesList: RouteType[]) => {
    return `
        <div class="block">
            ${routesList.map(route => {
                return createRouteNode(route)
            }).join('')}
        </div>
    `
}