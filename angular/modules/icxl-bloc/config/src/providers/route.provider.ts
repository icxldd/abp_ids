import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';
import { eBlocPolicyNames } from '../enums/policy-names';
import { eBlocRouteNames } from '../enums/route-names';

export const BLOC_ROUTE_PROVIDERS = [
  {
    provide: APP_INITIALIZER,
    useFactory: configureRoutes,
    deps: [RoutesService],
    multi: true,
  },
];

export function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '',
        name: eBlocRouteNames.Bloc,
        iconClass: 'fas fa-book',
        layout: eLayoutType.application,
        order: 10000,
        requiredPolicy: eBlocPolicyNames.Book,
      },{
        path: '/bloc',
        name: 'test',
        // iconClass: 'fas fa-book',
        parentName: eBlocRouteNames.Bloc,
        order: 1,
        requiredPolicy: eBlocPolicyNames.Book,
      }
    ]);
  };
}
