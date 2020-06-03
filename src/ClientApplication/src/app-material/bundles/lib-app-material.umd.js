(function (global, factory) {
    typeof exports === 'object' && typeof module !== 'undefined' ? factory(exports, require('@angular/core'), require('@angular/common'), require('@angular/material/autocomplete'), require('@angular/material/badge'), require('@angular/material/button'), require('@angular/material/button-toggle'), require('@angular/material/card'), require('@angular/material/checkbox'), require('@angular/material/chips'), require('@angular/material/core'), require('@angular/material/datepicker'), require('@angular/material/dialog'), require('@angular/material/divider'), require('@angular/material/expansion'), require('@angular/material/grid-list'), require('@angular/material/icon'), require('@angular/material/input'), require('@angular/material/list'), require('@angular/material/menu'), require('@angular/material/paginator'), require('@angular/material/progress-bar'), require('@angular/material/progress-spinner'), require('@angular/material/radio'), require('@angular/material/select'), require('@angular/material/sidenav'), require('@angular/material/slide-toggle'), require('@angular/material/slider'), require('@angular/material/snack-bar'), require('@angular/material/sort'), require('@angular/material/stepper'), require('@angular/material/table'), require('@angular/material/tabs'), require('@angular/material/toolbar'), require('@angular/material/tooltip')) :
    typeof define === 'function' && define.amd ? define('@lib/app-material', ['exports', '@angular/core', '@angular/common', '@angular/material/autocomplete', '@angular/material/badge', '@angular/material/button', '@angular/material/button-toggle', '@angular/material/card', '@angular/material/checkbox', '@angular/material/chips', '@angular/material/core', '@angular/material/datepicker', '@angular/material/dialog', '@angular/material/divider', '@angular/material/expansion', '@angular/material/grid-list', '@angular/material/icon', '@angular/material/input', '@angular/material/list', '@angular/material/menu', '@angular/material/paginator', '@angular/material/progress-bar', '@angular/material/progress-spinner', '@angular/material/radio', '@angular/material/select', '@angular/material/sidenav', '@angular/material/slide-toggle', '@angular/material/slider', '@angular/material/snack-bar', '@angular/material/sort', '@angular/material/stepper', '@angular/material/table', '@angular/material/tabs', '@angular/material/toolbar', '@angular/material/tooltip'], factory) :
    (global = global || self, factory((global.lib = global.lib || {}, global.lib['app-material'] = {}), global.ng.core, global.ng.common, global.ng.material.autocomplete, global.ng.material.badge, global.ng.material.button, global.ng.material['button-toggle'], global.ng.material.card, global.ng.material.checkbox, global.ng.material.chips, global.ng.material.core, global.ng.material.datepicker, global.ng.material.dialog, global.ng.material.divider, global.ng.material.expansion, global.ng.material['grid-list'], global.ng.material.icon, global.ng.material.input, global.ng.material.list, global.ng.material.menu, global.ng.material.paginator, global.ng.material['progress-bar'], global.ng.material['progress-spinner'], global.ng.material.radio, global.ng.material.select, global.ng.material.sidenav, global.ng.material['slide-toggle'], global.ng.material.slider, global.ng.material['snack-bar'], global.ng.material.sort, global.ng.material.stepper, global.ng.material.table, global.ng.material.tabs, global.ng.material.toolbar, global.ng.material.tooltip));
}(this, function (exports, core, common, autocomplete, badge, button, buttonToggle, card, checkbox, chips, core$1, datepicker, dialog, divider, expansion, gridList, icon, input, list, menu, paginator, progressBar, progressSpinner, radio, select, sidenav, slideToggle, slider, snackBar, sort, stepper, table, tabs, toolbar, tooltip) { 'use strict';

    /**
     * @fileoverview added by tsickle
     * @suppress {checkTypes,extraRequire,missingOverride,missingReturn,unusedPrivateMembers,uselessCode} checked by tsc
     */
    var AppMaterialModule = /** @class */ (function () {
        function AppMaterialModule() {
        }
        AppMaterialModule.decorators = [
            { type: core.NgModule, args: [{
                        declarations: [],
                        imports: [
                            common.CommonModule,
                            button.MatButtonModule,
                            menu.MatMenuModule,
                            toolbar.MatToolbarModule,
                            icon.MatIconModule,
                            sidenav.MatSidenavModule,
                            //MatSidenavContent,
                            card.MatCardModule
                        ],
                        exports: [
                            /*MatButtonModule,
                            MatMenuModule,
                            MatToolbarModule,
                            MatIconModule,
                            MatSidenavModule,
                            //MatSidenavContent,
                            MatCardModule*/
                            autocomplete.MatAutocompleteModule,
                            badge.MatBadgeModule,
                            button.MatButtonModule,
                            buttonToggle.MatButtonToggleModule,
                            card.MatCardModule,
                            checkbox.MatCheckboxModule,
                            chips.MatChipsModule,
                            datepicker.MatDatepickerModule,
                            dialog.MatDialogModule,
                            divider.MatDividerModule,
                            expansion.MatExpansionModule,
                            gridList.MatGridListModule,
                            icon.MatIconModule,
                            input.MatInputModule,
                            list.MatListModule,
                            menu.MatMenuModule,
                            core$1.MatNativeDateModule,
                            paginator.MatPaginatorModule,
                            progressBar.MatProgressBarModule,
                            progressSpinner.MatProgressSpinnerModule,
                            radio.MatRadioModule,
                            core$1.MatRippleModule,
                            select.MatSelectModule,
                            sidenav.MatSidenavModule,
                            slider.MatSliderModule,
                            slideToggle.MatSlideToggleModule,
                            snackBar.MatSnackBarModule,
                            sort.MatSortModule,
                            stepper.MatStepperModule,
                            table.MatTableModule,
                            tabs.MatTabsModule,
                            toolbar.MatToolbarModule,
                            tooltip.MatTooltipModule
                        ]
                    },] }
        ];
        return AppMaterialModule;
    }());

    exports.AppMaterialModule = AppMaterialModule;

    Object.defineProperty(exports, '__esModule', { value: true });

}));
//# sourceMappingURL=lib-app-material.umd.js.map
