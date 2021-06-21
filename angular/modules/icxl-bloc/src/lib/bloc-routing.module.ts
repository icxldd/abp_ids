import { AuthGuard, DynamicLayoutComponent, PermissionGuard, ReplaceableComponents, ReplaceableRouteContainerComponent } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestComponent } from './components/test/test.component';

const routes: Routes = [
  { path: '', redirectTo: 'audit', pathMatch: 'full' },
  {
    path: '',
    component: DynamicLayoutComponent,
    canActivate: [AuthGuard, PermissionGuard],
    children: [
      {
        path: '',
        pathMatch: 'full',
        component: TestComponent,
      },
      {
        path: 'test',
        component: TestComponent,
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class BlocRoutingModule {}
