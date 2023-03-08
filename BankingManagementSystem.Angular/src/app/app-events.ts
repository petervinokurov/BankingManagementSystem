import { Injectable, Output, EventEmitter } from "@angular/core";

@Injectable()
export class AppEvents {
    @Output() LoginEmitter: EventEmitter<void> = new EventEmitter();
    @Output() LogoutEmitter: EventEmitter<void> = new EventEmitter();

    constructor() {}
}
