import { bindable, bindingMode } from "aurelia-framework";

export class MasDurationCustomElement {
    @bindable({ defaultBindingMode: bindingMode.twoWay }) field: Duration;
    @bindable label: string;
}

export class Duration {
    public days: number;
    public months: number;
    public years: number;
}