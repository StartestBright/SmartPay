import React, { useState } from 'react';
import { Button, TextField, Grid, Typography, MenuItem } from '@mui/material';
import months from '@/utils/monthOptions';
import { MonthOption } from '@/models/MonthOptions';
import { PayslipFormData, PayslipResponse } from '@/models/payslip';
import { FormContainer } from '@/components/features/payslipForm/payslipFormStyles';

interface PayslipFormProps {
    calculatePayslip: (formData: PayslipFormData) => Promise<PayslipResponse>
}

const PayslipForm: React.FC<PayslipFormProps> = ({ calculatePayslip }) => {
    const [formData, setFormData] = useState<PayslipFormData>({
        firstName: '',
        lastName: '',
        annualSalary: 0,
        superRate: 0,
        month: '',
        year: new Date().getFullYear().toString(), // current year as default
    })

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: value });
    };

    // Handle form submission
    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        calculatePayslip(formData)
 
    };

    return (
        <FormContainer>
            <Typography variant="h6">Calculate Payslip</Typography>
            <form onSubmit={handleSubmit}>
                <Grid container spacing={3}>         
       
                    <Grid item xs={12} sm={6}>
                        <TextField required
                            label="First Name"
                            name="firstName"
                            fullWidth
                            value={formData.firstName}
                            onChange={handleChange}
                        />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                        <TextField required
                            label="Last Name"
                            name="lastName"
                            fullWidth
                            value={formData.lastName}
                            onChange={handleChange}
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <TextField required
                            label="Annual Salary"
                            name="annualSalary"
                            type="number"
                            fullWidth
                            value={formData.annualSalary}
                            onChange={handleChange}
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <TextField required
                            label="Super Rate (%)"
                            name="superRate"
                            type="number"
                            fullWidth
                            value={formData.superRate}
                            onChange={handleChange}
                        />
                    </Grid>
                    <Grid item xs={6}>
                        <TextField required
                            select
                            label="Month"
                            name="month"
                            value={formData.month}
                            fullWidth
                            onChange={handleChange}>
                            {months.map((option: MonthOption) => (
                                <MenuItem key={option.value} value={option.value}>
                                    {option.label}
                                </MenuItem>
                            ))}
                        </TextField>
                    </Grid>
                    <Grid item xs={6}>
                        <TextField required
                            label="Year"
                            name="year"
                            type="number"
                            fullWidth
                            value={formData.year}
                            onChange={handleChange}
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <Button type="submit" variant="contained" color="primary" fullWidth>
                            Calculate
                        </Button>
                    </Grid>
                </Grid>
            </form>        
        </FormContainer>
    );
}
export default PayslipForm;

