import { Product } from './Product';
import { CategoryProperty } from './CategoryProperty';

export class Category{

  public constructor(init?: Partial<Category>) {
    Object.assign(this, init);
  }

  categoryName: string;
  categoryDescription: string;
  productList: Product[];
  subCategories: Category[];
  categoryProperty: CategoryProperty[];
  parentCategoryId: string;
  id: string;
  customerId: string;
}
