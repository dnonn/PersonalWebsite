import { AppBar, Toolbar, Typography, useMediaQuery } from "@mui/material";
import Button from "@mui/material/Button";

const navLink = {
  padding: "5px 36px",
  fontSize: "18px",
  color: "#DCDCDC",
  borderRadius: "0px",
  borderStyle: "solid",
  borderWidth: "0px 0px 0px 1px",
  borderColor: "#DCDCDC",
  msTransform: "skewX(20deg)",
  WebkitTransform: "skewX(20deg)",
  transform: "skewX(-20deg)",
};

export default function Navigation() {
  const matches = useMediaQuery("only screen and (max-width: 900px)");

  return (
    <AppBar elevation={1}>
      <Toolbar>
        <Typography
          variant="h5"
          sx={{
            flex: 1,
          }}
        >
          David Nonn
        </Typography>
        {!matches && (
          <>
            <Button style={navLink} variant="contained" disableElevation>
              FORUM
            </Button>
            <Button style={navLink} variant="contained" disableElevation>
              CHAT
            </Button>
            <Button
              style={{ ...navLink, borderWidth: "0px 1px 0px 1px" }}
              variant="contained"
              disableElevation
            >
              SIGN IN
            </Button>
          </>
        )}
      </Toolbar>
    </AppBar>
  );
}
