import { ModuleWithProviders, NgModule } from '@angular/core';
import { BLOC_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class BlocConfigModule {
  static forRoot(): ModuleWithProviders<BlocConfigModule> {
    return {
      ngModule: BlocConfigModule,
      providers: [BLOC_ROUTE_PROVIDERS],
    };
  }
}
