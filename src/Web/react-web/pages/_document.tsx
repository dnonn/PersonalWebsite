import Document, { Html, Head, Main, NextScript } from "next/document";

const style = {
  margin: "0",
};

class MyDocument extends Document {
  render() {
    return (
      <Html lang="en">
        <Head />
        <body style={style}>
          <Main />
          <NextScript />
        </body>
      </Html>
    );
  }
}

export default MyDocument;
