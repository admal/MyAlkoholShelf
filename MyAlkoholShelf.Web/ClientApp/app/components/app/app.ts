import { Aurelia, PLATFORM } from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';

export class App {
    router: Router;

    configureRouter(config: RouterConfiguration, router: Router) {
        config.title = 'My alkohol shelf';
        config.map([
//            {
//                route: ['', 'home'],
//                name: 'home',
//                settings: { icon: 'home' },
//                moduleId: PLATFORM.moduleName('../home/home'),
//                nav: true,
//                title: 'Home'
//            },
//            {
//                route: 'counter',
//                name: 'counter',
//                settings: { icon: 'education' },
//                moduleId: PLATFORM.moduleName('../counter/counter'),
//                nav: true,
//                title: 'Counter'
//            },
//            {
//                route: 'fetch-data',
//                name: 'fetchdata',
//                settings: { icon: 'th-list' },
//                moduleId: PLATFORM.moduleName('../fetchdata/fetchdata'),
//                nav: true,
//                title: 'Przepisy'
//            },
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
            }
        ]
        );

        this.router = router;
    }
}
