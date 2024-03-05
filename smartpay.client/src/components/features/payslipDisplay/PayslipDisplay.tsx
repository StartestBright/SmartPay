import React from 'react';
import { PayslipResponse } from '@/models/payslip'; // Update the import path as necessary
import { Typography, Paper, Box } from '@mui/material';

interface PayslipDisplayProps {
    payslip: PayslipResponse
}

const PayslipDisplay: React.FC<PayslipDisplayProps> = ({payslip }) => {

    return (
        <Paper elevation={3}>
            <Box p={2}>
                <Typography variant="h6">{payslip.name}</Typography>
                <Typography>Pay Period: {payslip.payPeriod}</Typography>
                <Typography>Gross Income: {payslip.grossIncome}</Typography>
                <Typography>Income Tax: {payslip.incomeTax}</Typography>
                <Typography>Net Income: {payslip.netIncome}</Typography>
                <Typography>Super: {payslip.superAmount}</Typography>
            </Box>
        </Paper>
    )
};

export default PayslipDisplay;
