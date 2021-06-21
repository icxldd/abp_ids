import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { BlocRoutingModule } from './bloc-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { TestComponent } from './components/test/test.component';


@NgModule({
  declarations: [TestComponent],
  imports: [CoreModule, ThemeSharedModule, BlocRoutingModule,SharedModule],
  exports: [],
})
export class BlocModule {
  static forChild(): ModuleWithProviders<BlocModule> {
    return {
      ngModule: BlocModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<BlocModule> {
    return new LazyModuleFactory(BlocModule.forChild());
  }
}
