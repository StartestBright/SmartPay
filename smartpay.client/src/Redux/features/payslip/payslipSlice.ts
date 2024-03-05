import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { PayslipResponse } from '@/models/payslip';

interface PayslipResultState {
    result: PayslipResponse;
}

const initialState: PayslipResultState = {
    result: {
        name: "",
        payPeriod: "",
        grossIncome: 0,
        incomeTax: 0,
        netIncome: 0,
        superAmount: 0
    },
};

export const PayslipSlice = createSlice({
    name: 'payslip',
    initialState,
    reducers: {
        setPayslipResult: (state, action: PayloadAction<PayslipResponse>) => {
            state.result = action.payload;
        },
    },
});

export const { setPayslipResult } = PayslipSlice.actions;
export default PayslipSlice.reducer;
