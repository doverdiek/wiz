export const environment = {
  production: true,
  customer: window["env"]["customer"] || null,
  webshopinformationService: 'https://api.overdiek.nl/wsinformationservice/',
  webshopOrderService: "https://api.overdiek.nl/wsorderservice/"
};
