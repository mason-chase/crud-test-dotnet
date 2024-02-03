using Blazored.FluentValidation;
using Mc2.CrudTest.Presentation.Client.Models.Customers;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Mc2.CrudTest.Presentation.Shared.Extensions; 
using System.Net.Http.Json;

namespace Mc2.CrudTest.Presentation.Client.Pages.Catalog
{
    public partial class EditCustomer
    {
        private bool _loading = false;
        [Inject] private HttpClient _httpClient { get; set; }

        private FluentValidationValidator _fluentValidationValidator = new();
        private bool Validated => _fluentValidationValidator.Validate(options => { options.IncludeAllRuleSets(); });
        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }
        [Parameter] public UpdateCustomerDTO _updateCustomerDTOModel { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {

        }

        public void Cancel()
        {
            MudDialog.Cancel();
        }

        private async Task SaveAsync()
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/Customer/Edit", _updateCustomerDTOModel);
            var result = await response.ToResult<int>();
            if (result.Succeeded)
            {
                _snackBar.Add(result.Messages[0], Severity.Success);
                MudDialog.Close();
            }
            else
            {
                foreach (var message in result.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
        }
    }
}