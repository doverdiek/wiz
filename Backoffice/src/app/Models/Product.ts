export class Product {

  public constructor(init?: Partial<Product>) {
    Object.assign(this, init);
  }

  id: string;
  sku: number;
  name: string;
  price: number;
  discountPrice: number;
  wholeSalePrice: number;
  images: string;
  description: string;
  category: string;
  stock: number;
  quantity: number;
}
