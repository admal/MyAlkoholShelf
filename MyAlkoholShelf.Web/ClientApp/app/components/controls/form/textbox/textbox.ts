import { bindable, bindingMode } from "aurelia-framework";

export class TextboxCustomElement {
    @bindable({ defaultBindingMode: bindingMode.twoWay }) field: string;
    @bindable label: string;
    @bindable placeholder: string;
}