import { Grid } from "@mui/material";
import React from "react";

type Props = {
  children: React.ReactNode;
};

export default function Content(props: Props) {
  return (
    <>
      <Grid item xs={false} sm={2} />
      <Grid item xs={12} sm={8}>
        <main>{props.children}</main>
      </Grid>
      <Grid item xs={false} sm={2} />
    </>
  );
}
