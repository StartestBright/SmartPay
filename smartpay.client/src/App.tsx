import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Header from '@/components/common/Header';
import HomePage from '@/pages/Homepage';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { ReactQueryDevtools } from '@tanstack/react-query-devtools';


// Assume PayslipDisplay is a page/component that shows after submitting the form
// If it's not a separate page, integrate it directly where needed, perhaps in PayslipForm or another page
import NotFoundPage from '@/pages/NotFoundPage';


const queryClient = new QueryClient();
const App: React.FC = () => {
    return (
        <QueryClientProvider client={queryClient}>
            <ReactQueryDevtools/>
            <Router>
                <div className="App">
                    <Header />
                    <main style={{ width: "100vw" } }>
                        <Routes>
                            <Route path="/" element={<HomePage />} />
                            <Route path="*" element={<NotFoundPage />} />
                        </Routes>
                    </main>
                </div>
        </Router>
            </QueryClientProvider >

    );
};


export default App;
