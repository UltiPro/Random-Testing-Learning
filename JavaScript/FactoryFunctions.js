function createTaxCalculator(tax) {
    function calculateTax(amount) {
        return amount * tax;
    }
    return calculateTax;
}

const calculateVatAmount = createTaxCalculator(0.19);
const calculateIncomeTaxAmount = createTaxCalculator(0.25);

console.log(calculateVatAmount(100));
console.log(calculateVatAmount(200));