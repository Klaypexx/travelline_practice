import {createHtml} from "./components/createHtml"
import { swaggerLogic } from "./swaggerLogic";
import { routesList } from "./routesList";
import "./style.css";

const createHtmlNode = (htmlString: string | string[]) => {
  const placeholder = document.createElement("div");
  placeholder.innerHTML = typeof htmlString === `string` ? htmlString : htmlString.join(``);

  return placeholder.firstElementChild;
};

(() => {
  const appDiv = document.querySelector<HTMLDivElement>("#app");
  const node = createHtmlNode(createHtml(routesList));
  if (appDiv && node) {
    appDiv.append(node);
    routesList.forEach(route => {
      swaggerLogic(route);
    });
  }
})();
