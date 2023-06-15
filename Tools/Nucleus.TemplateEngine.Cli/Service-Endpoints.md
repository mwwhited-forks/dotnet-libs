# Swagger Description

## Endpoints 
{{#each this.paths}}

### {{@key}} 

{{#each this}}
HTTP Method: {{@key}}
Anonymous:   {{@value.x-permissions.anonymous}}
{{#if @value.x-permissions.right}}
Rights:
	{{#each @value.x-permissions.right}}
* {{@value}}
	{{/each}}
{{/if}}
{{#if @value.requestBody.content.[application/json].schema.[$ref]}}
Request:     {{@value.requestBody.content.[application/json].schema.[$ref]}}
{{/if}}{{#if @value.responses.[200].content.[application/json].schema.[$ref]}}{{set 'reference' @value.responses.[200].content.[application/json].schema.[$ref]}}{{set 'reference-key' (str-replace (get 'reference') '#/components/schemas/')}}{{set 'schema' (lookup ../../components.schemas (get 'reference-key'))}}
{{#with (lookup ../../components.schemas (get 'reference-key')) as |schema|}}
Response: {{#if schema.[title]}}{{schema.[title]}}{{else}}{{get 'reference'}}{{/if}}
{{/with}}

{{/if}}
{{/each}}
{{/each}}

## Models 
{{#each this.components.schemas}}

{{#if @value.title}}
### {{@value.title}} 

* {{@key}}

{{else}}
### {{@key}} 
{{/if}}

{{/each}}

