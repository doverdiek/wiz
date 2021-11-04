export enum ApiMethod {
  GET = "GET",
  POST = "POST" ,
  PUT = "PUT",
  DELETE = "DELETE"
};

export enum AuthEndPoints {
  //Authservice
  LOGIN = "Auth/login",
  REGISTER = "Auth/register",

  //Product service endpoints
  GET_PRODUCTS = "product/All",
  GET_PRODUCT_BY_ID = "product/",
  INSERT_PRODUCT = "product/Upsert",
  DELETE_PRODUCT = "product/Delete",

  //Category service endpoints
  GET_CATEGORY_BY_ID = "category/",
  GET_ALL_CATEGORIES = "category/All",
  ADD_CATEGORY = "category/Upsert",
  DELETE_CATEGORY = "category/Delete",

  //Subcategory service endpoints
  ADD_SUB_CATEGORY = "category/AddSubCategory",

  //Add product to category
  ADD_PRODUCT_TO_CATEGORY = "category/AddProduct",

  //Inventory add stock
  ADD_STOCK = "inventory/AddInventory",
  GET_PRODUCT_STOCK = "inventory/GetAllProductStock"
};

export enum httpOptions {
  HEADERS = "{'Content-Type':  'application/json'}"
};
