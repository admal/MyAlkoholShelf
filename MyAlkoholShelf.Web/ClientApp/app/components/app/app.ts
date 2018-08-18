import { Aurelia, PLATFORM } from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';

export class App {
    router: Router;

    configureRouter(config: RouterConfiguration, router: Router) {
        config.title = 'My alkohol shelf';
        config.map([
            {
                route: ['', 'recipies'],
                name: 'recipies',
                settings: { icon: 'th-list' },
                moduleId: PLATFORM.moduleName('../views/recipiesListView/recipiesListView'),
                nav: true,
                title: 'Przepisy'
            },
            {
                route: 'recipe/:id?',
                name: 'recipe',
                settings: { icon: 'th-list' },
                moduleId: PLATFORM.moduleName('../views/recipyAddEditView/recipyAddEditView'),
                nav: false,
                title: 'Przepis'
            },
            {
                route: 'alkohols',
                name: 'alkohols',
                settings: { icon: 'th-list' },
                moduleId: PLATFORM.moduleName('../views/alkoholsListView/alkoholsListView'),
                nav: true,
                title: 'Alkohole'
            }
        ]
        );

        this.router = router;
    }
}
