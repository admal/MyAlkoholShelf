import { bindable } from "aurelia-framework";

export class TextboxCustomElement {
    @bindable field: string;
    @bindable label: string;
    @bindable placeholder: string;


}