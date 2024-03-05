import styled from '@emotion/styled';
import { Box, Container } from '@mui/material';

export const HomeContainer = styled(Container)`

`

export const SpinnerOverlay = styled(Box)`
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(255, 255, 255, 0.7);
  z-index: 2;
  display: flex;
  justify-content: center;
  align-items: center;
`;
