# Eliassen.Handlebars.Extensions


## Class: Handlebars.Extensions.ServiceCollectionExtensions
Provides extension methods for configuring services related to Handlebars templates in the .
### Methods


#### TryAddHandlebarServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Adds services related to Handlebars templates to the specified .
    #####Parameters
    **services:** The to add the services to.

    ##### Return value
    The modified with added Handlebars template services.

## Class: Handlebars.Extensions.Templating.HandlebarsTemplateProvider
Provides Handlebars template processing functionality.
Initializes a new instance of the class.
    **hash:** The hash provider.

    **helpersRegistry:** The collection of helpers registries.

    **log:** The logger instance.

### Methods


####Constructor
Initializes a new instance of the class.
Provides Handlebars template processing functionality.
    #####Parameters
    **hash:** The hash provider.

    **helpersRegistry:** The collection of helpers registries.

    **log:** The logger instance.


#### CanApply(Eliassen.System.Text.Templating.ITemplateContext)
Determines whether this template provider can apply template processing to the given context.
    #####Parameters
    **context:** The template context.

    ##### Return value
    true if the template processing can be applied; otherwise, false.

#### ApplyAsync(Eliassen.System.Text.Templating.ITemplateContext,System.Object,System.IO.Stream)
Asynchronously applies Handlebars template processing to the specified context, data, and target stream.
    #####Parameters
    **context:** The template context.

    **data:** The data to be used during template processing.

    **target:** The target stream where the processed template is written.

    ##### Return value
    A task representing the asynchronous operation. The task result is true if successful, false otherwise.