import { PayslipFormData, PayslipResponse } from '@/models/payslip';

export const CalculatePayslip = async (formData: PayslipFormData) : Promise<PayslipResponse> => {
    try {
        const response = await fetch('/api/payslip', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(formData),
        });

        if (!response.ok) {
            throw new Error(`Error: ${response.status}`);
        }

        const data: PayslipResponse = await response.json();
        return data;
    } catch (error) {
        console.error("Failed to calculate payslip:", error);
        throw error;
    } 
}