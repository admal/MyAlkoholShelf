import { Duration } from "app/models/Duration";
import { bindable, bindingMode } from "aurelia-framework";

export class PreparationPhaseEditorCustomElement
{
    @bindable({ defaultBindingMode: bindingMode.twoWay }) initialPhases: AlkoholPreparationPhase[];
    
    constructor() {
        var duration = new Duration();
        duration.days = 10;
        duration.months = 1;
        duration.years = 0;
        this.initialPhases = [
            new AlkoholPreparationPhase("Faza 1", duration),
            new AlkoholPreparationPhase("Faza 2", duration),
            new AlkoholPreparationPhase("Faza 3", duration)
        ];
    }

    addRow(): void {
        this.initialPhases.push(new AlkoholPreparationPhase("Nowa faza", new Duration()));
    }
}

export class AlkoholPreparationPhase {
    constructor(name: string, phasePeriod: Duration) {
        this.name = name;
        this.phasePeriod = phasePeriod;
    }

    public name: string;
    public phasePeriod: Duration;

}