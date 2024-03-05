import { configureStore } from '@reduxjs/toolkit';
import LoadingReducer from '@/Redux/features/loading/loadingSlice';
import payslipReducer from '@/Redux/features/payslip/payslipSlice';

export const store = configureStore({
    reducer: {
        loading: LoadingReducer,
        payslip: payslipReducer
    }
});

// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof store.getState>
// Inferred type: {posts: PostsState, comments: CommentsState, users: UsersState}
export type AppDispatch = typeof store.dispatch