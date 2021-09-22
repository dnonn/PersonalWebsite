import { ThemeProvider } from "@emotion/react";
import { createTheme, CssBaseline } from "@mui/material";
import type { AppProps } from "next/app";
import Head from "next/head";
import React from "react";
import Layout from "../components/layout/layout";

const defaultTheme = createTheme({
  palette: {
    primary: {
      main: "#1F2E39",
    },
    secondary: {
      main: "#424242",
    },
    background: {
      default: "#212121",
      paper: "#424242",
    },
  },
  typography: {
    allVariants: {},
  },
  components: {
    MuiIcon: {
      styleOverrides: {
        root: {
          // Match 24px = 3 * 2 + 1.125 * 16
          color: "pink",
        },
      },
    },
  },
});

function MyApp({ Component, pageProps }: AppProps) {
  return (
    <ThemeProvider theme={defaultTheme}>
      <CssBaseline />
      <Layout>
        <Head>
          <meta name="viewport" content="width=device-width, initial-scale=1" />
        </Head>
        <Component {...pageProps} />
      </Layout>
    </ThemeProvider>
  );
}
export default MyApp;
