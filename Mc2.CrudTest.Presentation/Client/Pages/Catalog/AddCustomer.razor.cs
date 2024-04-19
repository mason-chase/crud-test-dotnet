using Blazored.FluentValidation;
using Mc2.CrudTest.Presentation.Client.Models.Customers;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http.Json;
using Mc2.CrudTest.Presentation.Shared.Extensions;

namespace Mc2.CrudTest.Presentation.Client.Pages.Catalog
{
    public partial class AddCustomer
    {
        private bool _loading = false;
        [Inject] private HttpClient _httpClient { get; set; }

        private FluentValidationValidator _fluentValidationValidator = new();
        private bool Validated => _fluentValidationValidator.Validate(options => { options.IncludeAllRuleSets(); });
        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }
        public CreateCustomerDTO _createCustomerDTOModel { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {

        }

        public void Cancel()
        {
            MudDialog.Cancel();
        }

        private async Task SaveAsync()
        {
            _loading = true;
            var response = await _httpClient.PostAsJsonAsync($"/api/Customer/Create", _createCustomerDTOModel);
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
            _loading = false;
        }
    }
}