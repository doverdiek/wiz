export class Inventory {
  public constructor(init?: Partial<Inventory>) {
    Object.assign(this, init);
  }

  id: string;
  productId: string;
  quantity: number;
  description: string;
  type: string;
  customerEmail: string;
  returnDate: string

}
