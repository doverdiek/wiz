import { Product } from 'src/app/core/models/Product';
import { CategoryProperty } from 'src/app/core/models/CategoryProperty';

export class Category{

  categoryName: string;
  categoryDescription: string;
  productList: Product[];
  subCategories: Category[];
  categoryProperty: CategoryProperty[];
  parentCategoryId: string;
  id: string;
  customerId: string;
  mainCategory: boolean;
  subCategoriesIds: string[];
  productIds: string[];
}
