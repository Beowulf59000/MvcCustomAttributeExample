// Condition : si la valeur est non nulle et si elle est égale à la valeur fournie, alors le test est OK

jQuery.validator.addMethod("requiredwithradiobutton", function (value, element, params) {
    var radioButtonValue = $('#' + params.radiobuttonproperty).val();

    if (radioButtonValue != params.valuetocompare)
        return true;
    else if (value != '')
        return true;
    else
        return false;
});

jQuery.validator.unobtrusive.adapters.add("requiredwithradiobutton", ["radiobuttonproperty", "valuetocompare"],
  function (options) {
      options.rules['requiredwithradiobutton'] = {
          radiobuttonproperty: options.params.radiobuttonproperty,
          valuetocompare: options.params.valuetocompare
      };
      options.messages['requiredwithradiobutton'] = options.message;
  }
);