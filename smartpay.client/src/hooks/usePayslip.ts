import { CalculatePayslip } from '@/services/PayslipService';
import { PayslipFormData } from '@/models/payslip'
import { useMutation } from '@tanstack/react-query';

const key = 'payslip'

export const usePayslip = () => {

    const payslip = useMutation({ mutationKey: [key], mutationFn: (formData: PayslipFormData) => CalculatePayslip(formData) })

    const calculatePayslip = async (formData: PayslipFormData) => payslip.mutateAsync(formData);
    return {
        payslip,
        calculatePayslip
    };
    
}