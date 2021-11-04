import { CategoryProperty } from './CategoryProperty';

export class Product {
  id: string;
  sku: number;
  name: string;
  price: number;
  discountPrice: number;
  wholeSalePrice: number;
  images: string;
  description: string;
  category: string;
  properties: CategoryProperty[];
  cartquantity: number;
}
