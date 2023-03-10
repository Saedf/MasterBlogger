using MB.Domain.ArticleCategoryAgg.Exception;

namespace MB.Domain.ArticleAgg.Services;

public class ArticleValidatorService:IArticleValidatorServices
{
    private readonly IArticleRepository _articleRepository;

    public ArticleValidatorService(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public void CheckedThatThisRecordAlreadyExists(string title)
    {
        if (_articleRepository.Exists(x=>x.Title==title))
        {
            throw new DuplicatedRecordException();
        }
    }
}