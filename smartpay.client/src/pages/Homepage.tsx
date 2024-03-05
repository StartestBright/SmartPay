import React from 'react';
import PayslipForm from '@/components/features/payslipForm/PayslipForm';
import PayslipDisplay from '@/components/features/payslipDisplay/PayslipDisplay';
import { CircularProgress } from '@mui/material';
import { SpinnerOverlay , HomeContainer } from './HomepageStyles';
import { usePayslip } from '../hooks/usePayslip';

const HomePage: React.FC = () => {

    const { payslip, calculatePayslip } = usePayslip();

    return (
        <HomeContainer>
            <PayslipForm calculatePayslip={calculatePayslip} />
            {payslip.data && <PayslipDisplay payslip={payslip.data} />}
            {payslip.isPending && (
                <SpinnerOverlay>
                    <CircularProgress />
                </SpinnerOverlay>
            )}
        </HomeContainer>
    )
}


export default HomePage;