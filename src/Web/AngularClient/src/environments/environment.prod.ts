export const environment = {
  production: true,
  OpenIdConnect: {
    Authority: "http://host.docker.internal:8000",
    ClientId: "AngularClient"
  },
  ResourceServer: {
    Endpoint: "http://host.docker.internal:8001"
  },
  CurrentUrl: "http://localhost:4200/"
};
