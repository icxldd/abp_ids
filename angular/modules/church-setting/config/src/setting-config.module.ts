import { ModuleWithProviders, NgModule } from '@angular/core';
import { Setting_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class SettingConfigModule {
  static forRoot(): ModuleWithProviders<SettingConfigModule> {
    return {
      ngModule: SettingConfigModule,
      providers: [Setting_ROUTE_PROVIDERS],
    };
  }
}
