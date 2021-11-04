import { INavData } from '@coreui/angular';

export const navItems: INavData[] = [
  {
    name: 'Dashboard',
    url: '/dashboard',
    icon: 'icon-speedometer',
  },
  {
    title: true,
    name: 'My store'
  },
  {
    name: 'Products',
    icon: 'icon-layers',
    children: [
      {
        name: 'All products',
        url: '/products',
        icon: 'icon-layers'
      },
      {
        name: 'Add',
        url: '/products/add',
        icon: 'icon-plus'
      }
    ]
  },
  {
    name: 'Categories',
    icon: 'icon-layers',
    children: [
      {
        name: 'All Categories',
        url: '/categories',
        icon: 'icon-layers'
      }
    ]
  },
  {
    name: 'Inventory',
    icon: 'icon-layers',
    children: [
      {
        name: 'Returns',
        url: '/inventory',
        icon: 'icon-layers'
      }
    ]
  }
];
