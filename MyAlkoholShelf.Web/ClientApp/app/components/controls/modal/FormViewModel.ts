import {ViewData} from "./ViewData"

export abstract class FormViewModel {
    activate(model : ViewData) {
        this.$view = model;
    }

    protected $view : ViewData;
}