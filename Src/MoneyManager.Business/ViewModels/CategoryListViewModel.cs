using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MoneyManager.Foundation.Model;
using MoneyManager.Foundation.OperationContracts;
using PropertyChanged;

namespace MoneyManager.Business.ViewModels
{
    [ImplementPropertyChanged]
    public class CategoryListViewModel : BaseViewModel
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly ITransactionRepository transactionRepository;

        private string searchText;

        public CategoryListViewModel(IRepository<Category> categoryRepository,
            ITransactionRepository transactionRepository)
        {
            this.categoryRepository = categoryRepository;
            this.transactionRepository = transactionRepository;
            Categories = AllCategories;
        }

        public bool IsSettingCall { get; set; }
        public ObservableCollection<Category> Categories { get; set; }


        private ObservableCollection<Category> AllCategories => categoryRepository.Data;

        public Category SelectedCategory
        {
            get
            {
                return transactionRepository.Selected == null
                    ? new Category()
                    : transactionRepository.Selected.Category;
            }
            set
            {
                if (value == null)
                {
                    return;
                }

                if (!IsSettingCall)
                {
                    transactionRepository.Selected.Category = value;
                    ((Frame) Window.Current.Content).GoBack();
                }
            }
        }

        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                Search();
            }
        }

        public void Search()
        {
            if (SearchText != string.Empty)
            {
                Categories = new ObservableCollection<Category>
                    (AllCategories.Where(x => x.Name != null && x.Name.ToLower().Contains(searchText.ToLower()))
                        .ToList());
            }
            else
            {
                Categories = AllCategories;
            }
        }
    }
}