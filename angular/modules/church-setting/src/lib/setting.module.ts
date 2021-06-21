import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { SettingRoutingModule } from './setting-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { TestComponent } from './components/test/test.component';


@NgModule({
  declarations: [TestComponent],
  imports: [CoreModule, ThemeSharedModule, SettingRoutingModule,SharedModule],
  exports: [],
})
export class SettingModule {
  static forChild(): ModuleWithProviders<SettingModule> {
    return {
      ngModule: SettingModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<SettingModule> {
    return new LazyModuleFactory(SettingModule.forChild());
  }
}
