Use feature module:

1. create a feature module and all required components, the module will be imported to AppModule automatically, and all components will be exported at creation.
2. import the feature module in the module that will use the feature module's components.
3. import the feature module/s components in the module's routing module and set path properly.

see example of PropertyModule (feature module) and DashboardModule that uses the components from PropertyModule.