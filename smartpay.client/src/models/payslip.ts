export interface PayslipFormData {
    firstName: string;
    lastName: string;
    annualSalary: number;
    superRate: number;
    month: string;
    year: string;
}

export interface PayslipResponse {
    name: string;
    payPeriod: string;
    grossIncome: number;
    incomeTax: number;
    netIncome: number;
    superAmount: number;
}