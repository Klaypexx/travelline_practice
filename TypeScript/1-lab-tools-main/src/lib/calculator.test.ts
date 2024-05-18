import { Calculator } from "./calculator.js";

describe("Calculator", () => {
  describe("sum", () => {
    it("gets sum of couple of number", () => expect(Calculator.sum(41, 1)).toEqual(42));
  });
});
