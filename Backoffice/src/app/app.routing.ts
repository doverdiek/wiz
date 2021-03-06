import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// Import Containers
import { DefaultLayoutComponent } from './containers';

import { P404Component } from './views/error/404.component';
import { P500Component } from './views/error/500.component';
import { LoginComponent } from './views/login/login.component';
import { RegisterComponent } from './views/register/register.component';
import { AuthGuard } from './core/guards/AuthGuard';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full',
  },
  {
    path: '404',
    component: P404Component,
    data: {
      title: 'Page 404'
    }
  },
  {
    path: '500',
    component: P500Component,
    data: {
      title: 'Page 500'
    }
  },
  {
    path: 'login',
    component: LoginComponent,
    data: {
      title: 'Login Page'
    }
  },
  {
    path: 'register',
    component: RegisterComponent,
    data: {
      title: 'Register Page'
    }
  },
  {
    path: '',
    canActivate: [AuthGuard],
    component: DefaultLayoutComponent,
    data: {
      title: 'Home'
    },
    children: [
      {
        path: 'base',
        canActivate: [AuthGuard],
        loadChildren: () => import('./views/base/base.module').then(m => m.BaseModule),
      },
      { path: 'products',
        canActivate: [AuthGuard],
        loadChildren: () => import('./containers/products/product.module').then(m => m.ProductModule),
      },
      { path: 'categories',
        canActivate: [AuthGuard],
        loadChildren: () => import('./containers/categories/category.module').then(m => m.CategoryModule)
      },
      { path: 'inventory',
        canActivate: [AuthGuard],
        loadChildren: () => import('./containers/inventory/inventory.module').then(m => m.InventoryModule)
      },
      {
        path: 'buttons',
        canActivate: [AuthGuard],
        loadChildren: () => import('./views/buttons/buttons.module').then(m => m.ButtonsModule)
      },
      {
        path: 'charts',
        canActivate: [AuthGuard],
        loadChildren: () => import('./views/chartjs/chartjs.module').then(m => m.ChartJSModule)
      },
      {
        path: 'dashboard',
        canActivate: [AuthGuard],

        loadChildren: () => import('./views/dashboard/dashboard.module').then(m => m.DashboardModule)
      },
      {
        path: 'icons',
        canActivate: [AuthGuard],
        loadChildren: () => import('./views/icons/icons.module').then(m => m.IconsModule)
      },
      {
        path: 'notifications',
        canActivate: [AuthGuard],
        loadChildren: () => import('./views/notifications/notifications.module').then(m => m.NotificationsModule)
      },
      {
        path: 'theme',
        canActivate: [AuthGuard],
        loadChildren: () => import('./views/theme/theme.module').then(m => m.ThemeModule)
      },
      {
        path: 'widgets',
        canActivate: [AuthGuard],
        loadChildren: () => import('./views/widgets/widgets.module').then(m => m.WidgetsModule)
      },

    ]
  },
  { path: '**', component: P404Component },
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
