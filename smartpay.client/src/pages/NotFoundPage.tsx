import React from 'react';
import { Box, Typography, Button } from '@mui/material';
import { useNavigate } from 'react-router-dom';

const NotFoundPage: React.FC = () => {
    const navigate = useNavigate(); 

    return (
        <Box textAlign="center" pt={5}>
            <Typography variant="h4" gutterBottom>
                404 - Page Not Found
            </Typography>
            <Typography variant="subtitle1" gutterBottom>
                The page you are looking for might have been removed or is temporarily unavailable.
            </Typography>
            <Button variant="contained" color="primary" onClick={() => navigate('/')}>
                Go to Homepage
            </Button>
        </Box>
    );
};

export default NotFoundPage;
