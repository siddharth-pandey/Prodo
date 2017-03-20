import { Component, AfterViewInit} from '@angular/core';
import { ToasterService } from 'angular2-toaster';

@Component({
  moduleId: module.id,
  selector: 'prodo',
  templateUrl: 'app.component.html'
})
export class AppComponent implements AfterViewInit{

    constructor(private toasterService: ToasterService) {
        
    }

    ngAfterViewInit(): void {
        this.toasterService.popAsync('success', 'Welcome', 'Prodo is ready to be used.');
    }


}
